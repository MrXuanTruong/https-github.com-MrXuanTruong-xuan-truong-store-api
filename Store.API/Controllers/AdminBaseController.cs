using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.Core;
using DataTables.Queryable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Store.API.Extentions;
using Store.API.Infrastructure;
using Store.API.Models;
using Store.Services.Helpers;
using Store.Entity.Domains;

namespace Store.API.Controllers
{
    [Authorize]
    public abstract class AdminBaseController : BaseController
    {
        private AccountModel currentOperator;

        public AccountModel CurrentUser
        {
            get
            {
                if (currentOperator == null && User.Claims.Any())
                {
                    currentOperator = new AccountModel();
                    currentOperator.Id = int.Parse(User.Claims.Where(x => x.Type == ClaimType.Id).First().Value);
                    currentOperator.Username = User.Claims.Where(x => x.Type == ClaimType.Username).First().Value;
                    currentOperator.Email = User.Claims.Where(x => x.Type == ClaimType.Email).First().Value;
                    currentOperator.Fullname = User.Claims.Where(x => x.Type == ClaimType.Fullname).First().Value;
                    currentOperator.Phone = User.Claims.Where(x => x.Type == ClaimType.Phone).First().Value;
                    currentOperator.Address = User.Claims.Where(x => x.Type == ClaimType.Address).First().Value;
                    currentOperator.Permissions = JsonConvert.DeserializeObject<List<string>>(User.Claims.Where(x => x.Type == ClaimType.Permissions).First().Value);
                }
                return currentOperator;
            }
        }

        protected string SuccessMessage
        {
            get
            {
                return $"Thao tác thành công";
            }
        }

        protected string FailMessage
        {
            get
            {
                return $"Thao tác không thành công";
            }
        }

        protected string NoFoundMessage
        {
            get
            {
                return $"Thông tin không tồn tại";
            }
        }

        public dynamic ToDataTableResponse<T>(IQueryable<T> filteredData, IDataTablesRequest request)
        {
            var drawString = Request.Query["draw"];
            if (filteredData != null)
            {
                if (!string.IsNullOrEmpty(request.Search.Value))
                {
                    var searchFields = request.Columns.Where(x => x.IsSearchable).Select(x => x.Name);
                    var searchText = request.Search.Value.ToLower().ConvertVN();
                    filteredData = filteredData.Where(_item => _item.IsMatch(searchText, searchFields));
                }

                // Paging filtered data.
                // Paging is rather manual due to in-memmory (IEnumerable) data.
                var filtered = filteredData.SortAndPage<T>(request);

                return new
                {
                    draw = request.Draw,
                    recordsFiltered = filteredData.Count(),
                    recordsTotal = filteredData.Count(),
                    data = filtered
                };
            }
            else
            {
                return new
                {
                    draw = drawString,
                    recordsFiltered = 0,
                    recordsTotal = 0,
                    data = new List<T>()
                };
            }
        }

        public dynamic ToDataTableResponse<T>(IQueryable<T> data)
        {
            var drawString = Request.Query["draw"];
            if (data != null)
            {
                var request = new DataTablesRequest<T>(Request.QueryString.ToString());
                var filtered = data.ToPagedList(request);
                int draw = Convert.ToInt32(drawString);

                return new
                {
                    draw,
                    recordsFiltered = filtered.TotalCount,
                    recordsTotal = filtered.TotalCount,
                    data = filtered
                };
            }
            else
            {
                return new
                {
                    draw = drawString,
                    recordsFiltered = 0,
                    recordsTotal = 0,
                    data = new List<T>()
                };
            }
        }

        public dynamic ToDataTableResponse<T>(IPagedList<T> filtered)
        {
            var drawString = Request.Query["draw"];
            if (filtered != null)
            {
                int draw = Convert.ToInt32(drawString);

                return new
                {
                    draw,
                    recordsFiltered = filtered.TotalCount,
                    recordsTotal = filtered.TotalCount,
                    data = filtered
                };
            }
            else
            {
                return new
                {
                    draw = drawString,
                    recordsFiltered = 0,
                    recordsTotal = 0,
                    data = new List<T>()
                };
            }
        }

        public dynamic ToDataTableResponse<T>()
        {
            var drawString = Request.Query["draw"];

            return new
            {
                draw = drawString,
                recordsFiltered = 0,
                recordsTotal = 0,
                data = new List<T>()
            };
        }

        protected void ApplyUserCreateEntity(Store.Entity.Domains.Entity entity)
        {
            if (CurrentUser != null)
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.CreatedBy = CurrentUser.Id;
                entity.CreatedByName = CurrentUser.Username;
            }
        }

        protected void ApplyUserUpdateEntity(Store.Entity.Domains.Entity entity)
        {
            if (CurrentUser != null)
            {
                entity.UpdatedDate = DateTime.UtcNow;
                entity.UpdatedBy = CurrentUser.Id;
                entity.UpdatedByName = CurrentUser.Username;
            }
        }
    }
}
