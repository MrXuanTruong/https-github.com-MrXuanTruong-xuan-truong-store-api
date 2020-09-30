(function (global, factory) {
  typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports) :
  typeof define === 'function' && define.amd ? define(['exports'], factory) :
  (factory((global.contentLoaders = {})));
}(this, (function (exports) { 'use strict';

  var nestRE = /^(attrs|props|on|nativeOn|class|style|hook)$/;

  var babelHelperVueJsxMergeProps = function mergeJSXProps (objs) {
    return objs.reduce(function (a, b) {
      var aa, bb, key, nestedKey, temp;
      for (key in b) {
        aa = a[key];
        bb = b[key];
        if (aa && nestRE.test(key)) {
          // normalize class
          if (key === 'class') {
            if (typeof aa === 'string') {
              temp = aa;
              a[key] = aa = {};
              aa[temp] = true;
            }
            if (typeof bb === 'string') {
              temp = bb;
              b[key] = bb = {};
              bb[temp] = true;
            }
          }
          if (key === 'on' || key === 'nativeOn' || key === 'hook') {
            // merge functions
            for (nestedKey in bb) {
              aa[nestedKey] = mergeFn(aa[nestedKey], bb[nestedKey]);
            }
          } else if (Array.isArray(aa)) {
            a[key] = aa.concat(bb);
          } else if (Array.isArray(bb)) {
            a[key] = [aa].concat(bb);
          } else {
            for (nestedKey in bb) {
              aa[nestedKey] = bb[nestedKey];
            }
          }
        } else {
          a[key] = b[key];
        }
      }
      return a
    }, {})
  };

  function mergeFn (a, b) {
    return function () {
      a && a.apply(this, arguments);
      b && b.apply(this, arguments);
    }
  }

  var uid = (function () {
    return Math.random().toString(36).substring(2);
  });

  var ContentLoader = {
    name: 'ContentLoader',
    functional: true,
    props: {
      width: {
        type: [Number, String],
        "default": 400
      },
      height: {
        type: [Number, String],
        "default": 130
      },
      speed: {
        type: Number,
        "default": 2
      },
      preserveAspectRatio: {
        type: String,
        "default": 'xMidYMid meet'
      },
      baseUrl: {
        type: String,
        "default": ''
      },
      primaryColor: {
        type: String,
        "default": '#f9f9f9'
      },
      secondaryColor: {
        type: String,
        "default": '#ecebeb'
      },
      primaryOpacity: {
        type: Number,
        "default": 1
      },
      secondaryOpacity: {
        type: Number,
        "default": 1
      },
      uniqueKey: {
        type: String
      },
      animate: {
        type: Boolean,
        "default": true
      }
    },
    render: function render(h, _ref) {
      var props = _ref.props,
          data = _ref.data,
          children = _ref.children;
      var idClip = props.uniqueKey ? props.uniqueKey + "-idClip" : uid();
      var idGradient = props.uniqueKey ? props.uniqueKey + "-idGradient" : uid();
      return h("svg", babelHelperVueJsxMergeProps([data, {
        attrs: {
          viewBox: "0 0 " + props.width + " " + props.height,
          version: "1.1",
          preserveAspectRatio: props.preserveAspectRatio
        }
      }]), [h("rect", {
        style: {
          fill: "url(" + props.baseUrl + "#" + idGradient + ")"
        },
        attrs: {
          "clip-path": "url(" + props.baseUrl + "#" + idClip + ")",
          x: "0",
          y: "0",
          width: props.width,
          height: props.height
        }
      }), h("defs", [h("clipPath", {
        attrs: {
          id: idClip
        }
      }, [children || h("rect", {
        attrs: {
          x: "0",
          y: "0",
          rx: "5",
          ry: "5",
          width: props.width,
          height: props.height
        }
      })]), h("linearGradient", {
        attrs: {
          id: idGradient
        }
      }, [h("stop", {
        attrs: {
          offset: "0%",
          "stop-color": props.primaryColor,
          "stop-opacity": props.primaryOpacity
        }
      }, [props.animate ? h("animate", {
        attrs: {
          attributeName: "offset",
          values: "-2; 1",
          dur: props.speed + "s",
          repeatCount: "indefinite"
        }
      }) : null]), h("stop", {
        attrs: {
          offset: "50%",
          "stop-color": props.secondaryColor,
          "stop-opacity": props.secondaryOpacity
        }
      }, [props.animate ? h("animate", {
        attrs: {
          attributeName: "offset",
          values: "-1.5; 1.5",
          dur: props.speed + "s",
          repeatCount: "indefinite"
        }
      }) : null]), h("stop", {
        attrs: {
          offset: "100%",
          "stop-color": props.primaryColor,
          "stop-opacity": props.primaryOpacity
        }
      }, [props.animate ? h("animate", {
        attrs: {
          attributeName: "offset",
          values: "-1; 2",
          dur: props.speed + "s",
          repeatCount: "indefinite"
        }
      }) : null])])])]);
    }
  };

  var BulletListLoader = {
    name: 'BulletListLoader',
    functional: true,
    render: function render(h, _ref) {
      var data = _ref.data;
      return h(ContentLoader, data, [h("circle", {
        attrs: {
          cx: "10",
          cy: "20",
          r: "8"
        }
      }), h("rect", {
        attrs: {
          x: "25",
          y: "15",
          rx: "5",
          ry: "5",
          width: "220",
          height: "10"
        }
      }), h("circle", {
        attrs: {
          cx: "10",
          cy: "50",
          r: "8"
        }
      }), h("rect", {
        attrs: {
          x: "25",
          y: "45",
          rx: "5",
          ry: "5",
          width: "220",
          height: "10"
        }
      }), h("circle", {
        attrs: {
          cx: "10",
          cy: "80",
          r: "8"
        }
      }), h("rect", {
        attrs: {
          x: "25",
          y: "75",
          rx: "5",
          ry: "5",
          width: "220",
          height: "10"
        }
      }), h("circle", {
        attrs: {
          cx: "10",
          cy: "110",
          r: "8"
        }
      }), h("rect", {
        attrs: {
          x: "25",
          y: "105",
          rx: "5",
          ry: "5",
          width: "220",
          height: "10"
        }
      })]);
    }
  };

  var CodeLoader = {
    name: 'CodeLoader',
    functional: true,
    render: function render(h, _ref) {
      var data = _ref.data;
      return h(ContentLoader, data, [h("rect", {
        attrs: {
          x: "0",
          y: "0",
          rx: "3",
          ry: "3",
          width: "70",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "80",
          y: "0",
          rx: "3",
          ry: "3",
          width: "100",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "190",
          y: "0",
          rx: "3",
          ry: "3",
          width: "10",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "15",
          y: "20",
          rx: "3",
          ry: "3",
          width: "130",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "155",
          y: "20",
          rx: "3",
          ry: "3",
          width: "130",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "15",
          y: "40",
          rx: "3",
          ry: "3",
          width: "90",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "115",
          y: "40",
          rx: "3",
          ry: "3",
          width: "60",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "185",
          y: "40",
          rx: "3",
          ry: "3",
          width: "60",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "60",
          rx: "3",
          ry: "3",
          width: "30",
          height: "10"
        }
      })]);
    }
  };

  var FacebookLoader = {
    name: 'FacebookLoader',
    functional: true,
    render: function render(h, _ref) {
      var data = _ref.data;
      return h(ContentLoader, data, [h("rect", {
        attrs: {
          x: "70",
          y: "15",
          rx: "4",
          ry: "4",
          width: "117",
          height: "6.4"
        }
      }), h("rect", {
        attrs: {
          x: "70",
          y: "35",
          rx: "3",
          ry: "3",
          width: "85",
          height: "6.4"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "80",
          rx: "3",
          ry: "3",
          width: "350",
          height: "6.4"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "100",
          rx: "3",
          ry: "3",
          width: "380",
          height: "6.4"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "120",
          rx: "3",
          ry: "3",
          width: "201",
          height: "6.4"
        }
      }), h("circle", {
        attrs: {
          cx: "30",
          cy: "30",
          r: "30"
        }
      })]);
    }
  };

  var ListLoader = {
    name: 'ListLoader',
    functional: true,
    render: function render(h, _ref) {
      var data = _ref.data;
      return h(ContentLoader, data, [h("rect", {
        attrs: {
          x: "0",
          y: "0",
          rx: "3",
          ry: "3",
          width: "250",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "20",
          y: "20",
          rx: "3",
          ry: "3",
          width: "220",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "20",
          y: "40",
          rx: "3",
          ry: "3",
          width: "170",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "60",
          rx: "3",
          ry: "3",
          width: "250",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "20",
          y: "80",
          rx: "3",
          ry: "3",
          width: "200",
          height: "10"
        }
      }), h("rect", {
        attrs: {
          x: "20",
          y: "100",
          rx: "3",
          ry: "3",
          width: "80",
          height: "10"
        }
      })]);
    }
  };

  var InstagramLoader = {
    name: 'InstagramLoader',
    functional: true,
    render: function render(h, _ref) {
      var data = _ref.data;
      return h(ContentLoader, babelHelperVueJsxMergeProps([data, {
        attrs: {
          height: 480
        }
      }]), [h("circle", {
        attrs: {
          cx: "30",
          cy: "30",
          r: "30"
        }
      }), h("rect", {
        attrs: {
          x: "75",
          y: "13",
          rx: "4",
          ry: "4",
          width: "100",
          height: "13"
        }
      }), h("rect", {
        attrs: {
          x: "75",
          y: "37",
          rx: "4",
          ry: "4",
          width: "50",
          height: "8"
        }
      }), h("rect", {
        attrs: {
          x: "0",
          y: "70",
          rx: "5",
          ry: "5",
          width: "400",
          height: "400"
        }
      })]);
    }
  };

  exports.ContentLoader = ContentLoader;
  exports.BulletListLoader = BulletListLoader;
  exports.CodeLoader = CodeLoader;
  exports.FacebookLoader = FacebookLoader;
  exports.ListLoader = ListLoader;
  exports.InstagramLoader = InstagramLoader;

  Object.defineProperty(exports, '__esModule', { value: true });

})));
