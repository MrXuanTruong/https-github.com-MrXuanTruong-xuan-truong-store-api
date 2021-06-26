using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.API.Models;
using Store.API.Models.Order;
using Store.API.Services;
using Store.Entity.Domains;
using Store.Entity.Enums;
using Store.Services;
using Store.Services.EmailServices;

namespace Store.API.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IViewRenderService _viewRenderService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        private readonly IVoucherService _voucherService;
        private readonly IEmailService _emailService;
        //private object product;

        public OrderController(
            IProductService productService,
            IOrderService orderService,
            IVoucherService voucherService,
            IMapper mapper,
            IAccountService accountService,
            IEmailService emailService,
            IViewRenderService viewRenderService,
            ILogger<OrderController> logger)
        {
            _productService = productService;
            _orderService = orderService;
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
            _voucherService = voucherService;
            _emailService = emailService;
            _viewRenderService = viewRenderService;

        }

        //api/product/id
        [HttpGet("{id:int}")]
        public async Task<OrderRequestModel> GetById(int id)
        {
            OrderRequestModel response;
            var order = await _orderService.GetById(id);
            if (order != null)
            {
                response = new OrderRequestModel
                {
                    OrderId = order.OrderId,
                    OrderCode = order.OrderCode,
                    Email = order.Email,
                    Discount = order.Discount,
                    ContactName = order.ContactName,
                    Address = order.Address,
                    CustomerId = order.CustomerId,
                    Note = order.Note,
                    OrderStatusId = order.OrderStatusId,
                    OrderStatusName = order.OrderStatus?.OrderStatusName,
                    Phone = order.Phone,
                    TotalAmount = order.TotalAmount,
                    TotalPrice = order.TotalPrice,
                    PaymentMethodId = order.PaymentMethodId,
                    BranchId = order.BranchId,
                    OrderDetails = order.OrderDetails
                        .Select(x => new OrderDetailItemModel
                        {
                            ColorId = x.ColorId,
                            ColorName = x.Color?.ColorName,
                            OrderDetailId = x.OrderDetailId,
                            OrderId = x.OrderId,
                            Price = x.Price,
                            ProductId = x.ProductId,
                            ProductName = x.Product?.ProductName,
                            Quantity = x.Quantity
                        })
                        .ToList(),
                };
            }
            else
            {
                response = new OrderRequestModel
                {
                };
            }

            return response;
        }

        [HttpGet("GetList")]
        public dynamic GetList([FromQuery] OrderCriteriaModel criteria, [FromQuery] IDataTablesRequest request)
        {
            try
            {

                var query = _orderService.GetAll();
                var orders =
                    query
                    .Select(x => new OrderItemModel
                    {
                        OrderId = x.OrderId,
                        OrderStatusId = x.OrderStatusId,
                        OrderStatusName = x.OrderStatus.OrderStatusName,
                        ContactName = x.ContactName,
                        Phone = x.Phone,
                        Email = x.Email,
                        Address = x.Address,
                        TotalPrice = x.TotalPrice,
                        Note = x.Note,
                        OrderCode = x.OrderCode,
                        CreatedDate = x.CreatedDate,
                    })
                    .ToList()
                    .AsQueryable();

                var filteredData = orders;

                return ToDataTableResponse<OrderItemModel>(filteredData, request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return ToDataTableResponse<OrderItemModel>();
            }
        }

        [HttpPost]
        public async Task<CreateOrderResponseModel> CreateOrder([FromBody] CreateOrderRequestModel model)
        {
            var response = new CreateOrderResponseModel
            {
                Result = false,
            };

            Voucher voucher = null;
            if (model.VoucherCode != null)
            {
                voucher =
                _voucherService.GetAll()
                .Where(x => x.VoucherCode == model.VoucherCode && x.IsDeleted == 0 && x.IsUsed == 0)
                .FirstOrDefault();


                if (voucher != null)
                {
                    if (voucher.StartDate <= DateTime.Now && voucher.EndDate >= DateTime.Now)
                    {

                    }
                    else
                    {
                        voucher = null;
                    }
                }
            }

            var order = new Order
            {
                ContactName = model.ContactName,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                PaymentMethodId = PaymentMethodEnum.PAYMENT_AT_STORE,
                OrderStatusId = OrderStatusEnum.WAIT,
                Discount = 0,
                TotalAmount = 0,
                TotalPrice = 0,
                Note = model.Note,
                OrderDetails = new List<OrderDetail>(),
            };

            if(voucher != null)
            {
                order.VoucherId = voucher.VoucherId;
                order.Discount = (double)voucher.Price;
            }

            //if(model.VoucherCode != null)
            //{
            //    var voucher = GetById from DB;

            //    order.Discount = voucher.Value;
            //}

            var currentUser = CurrentUser;
            if (currentUser != null)
            {
                order.CustomerId = currentUser.Id;
            }

            ApplyUserCreateEntity(order);


            double total = 0;
            foreach (var detail in model.OrderDetails)
            {
                var product = await _productService.GetByIdWithoutInclude(detail.ProductId);
                total += (double)product.Price * detail.Quantity;

                var orderDetail = new OrderDetail
                {
                    ColorId = detail.ColorId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    Price = (double)product.Price,
                };

                ApplyUserCreateEntity(orderDetail);

                order.OrderDetails.Add(orderDetail);
            }

            order.TotalAmount = total;
            order.TotalPrice = total - order.Discount;

            order.OrderCode = DateTime.Now.ToString("yyyyMMddHHmmss");

            response.Result = await _orderService.Insert(order);

            //response.Messages.Add(response.Result ? SuccessMessage : FailMessage);

            if(response.Result == true)
            {
                response.Messages.Add(SuccessMessage);

                // Send Email
                var subject = "Đặt hàng thành công";
                var bodyHtml = await _viewRenderService.RenderToStringAsync<Order>("EmailTemplates/OrderEmailTemplate", order);
                var alias = "";
                await _emailService.Send(subject, bodyHtml, alias, new List<string>() { order.Email });

                if (voucher != null)
                {
                    voucher.IsUsed = 1;
                    await _voucherService.Update(voucher);
                }
            }
            else
            {
                response.Messages.Add(FailMessage);
            }

            if (response.Result)
            {
                response.OrderId = order.OrderId;
                response.OrderCode = order.OrderCode;
            }

            return response;

        }

        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> UpdateOrder(long id, [FromBody] UpdateOrderRequestModel model)
        {
            var response = new ResponseViewModel
            {
                Result = false,
            };

            var order = await _orderService.GetById(id);
            if (order == null)
            {

                response.Messages.Add("Không tìm thấy Đơn hàng");
            }
            else
            {
                order.ContactName = model.ContactName;
                order.Phone = model.Phone;
                order.Email = model.Email;
                order.Address = model.Address;
                order.OrderStatusId = model.OrderStatusId;
                order.Note = model.Note;
                order.BranchId = model.BranchId;
                order.PaymentMethodId = model.PaymentMethodId;

                foreach(var orderDetailModel in model.OrderDetails)
                {
                    var orderDetail = order.OrderDetails.Where(x => x.OrderDetailId == orderDetailModel.OrderDetailId).FirstOrDefault();
                    if(orderDetail != null)
                    {
                        orderDetail.ColorId = orderDetailModel.ColorId;
                        orderDetail.Quantity = orderDetailModel.Quantity;
                        // Ko update Price và ProductId => Đã chọn lucs mua rồi thì thôi
                        // Còn color, Branch, Số lượng thì admin có thể edit dc... nên cho update
                    }
                }

                response.Result = await _orderService.Update(order);

                response.Messages.Add(response.Result ? SuccessMessage : FailMessage);
            }

            return response;

        }

        [AllowAnonymous]
        [HttpGet("detail/{id:int}")]
        public async Task<OrderRequestModel> GetOrder(int id)
        {
            OrderRequestModel response;
            var order = await _orderService.GetById(id);
            if (order != null)
            {
                response = new OrderRequestModel
                {
                    OrderId = order.OrderId,
                    OrderCode = order.OrderCode,
                    Email = order.Email,
                    Discount = order.Discount,
                    ContactName = order.ContactName,
                    Address = order.Address,
                    CustomerId = order.CustomerId,
                    Note = order.Note,
                    OrderStatusId = order.OrderStatusId,
                    OrderStatusName = order.OrderStatus?.OrderStatusName,
                    Phone = order.Phone,
                    TotalAmount = order.TotalAmount,
                    TotalPrice = order.TotalPrice,
                    PaymentMethodId = order.PaymentMethodId,
                    PaymentMethodName = order.PaymentMethod?.PaymentMethodName,
                    OrderDetails = order.OrderDetails?
                        .Select(x => new OrderDetailItemModel
                        {
                            ColorId = x.ColorId,
                            ColorName = x.Color?.ColorName,
                            OrderDetailId = x.OrderDetailId,
                            OrderId = x.OrderId,
                            Price = x.Price,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            ProductName = x.Product?.ProductName,
                            ThumbnailUrl = x.Product?.ThumnailUrl,
                        })
                        .ToList(),
                };
            }
            else
            {
                response = new OrderRequestModel
                {
                };
            }

            return response;
        }
    }
}
