require.siteNS && require.siteNS(["home", "common"]);
require.resourceMap({
    "res": {
        "common:widget/ui/arch/router.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/arch/router_1670dcf.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/arch/app.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/arch/app_c1dac05.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/arch/router.js"]
        },
        "common:widget/ui/base/EventDispatcher.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/base/EventDispatcher_e71d337.js",
            "pkg": "common:p1"
        },
        "common:widget/ui/base/events.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/base/events_f8b4e1f.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/EventDispatcher.js"]
        },
        "common:widget/ui/arch/behavior/pageresizer.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/arch/behavior/pageresizer_9f05f70.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/events.js"]
        },
        "common:widget/ui/arch/localdb.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/arch/localdb_1fa8a65.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/arch/collection.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/arch/collection_8624f21.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/events.js",
                "common:widget/ui/arch/localdb.js"
            ]
        },
        "common:widget/ui/arch/handlers.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/arch/handlers_2d9d42f.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/events/events.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/events/events_87337df.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/EventDispatcher.js"]
        },
        "common:widget/ui/utils/scroller.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/utils/scroller_efc1f29.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/events/events.js"]
        },
        "common:widget/ui/utils/pageresizer.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/utils/pageresizer_9feba52.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/events/events.js"]
        },
        "common:widget/ui/utils/utils.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/utils/utils_bd26384.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/utils/scroller.js",
                "common:widget/ui/utils/pageresizer.js"
            ]
        },
        "common:widget/ui/arch/history.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/arch/history_dbb6541.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/utils/utils.js",
                "common:widget/ui/base/events.js"
            ]
        },
        "common:widget/ui/arch/model.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/arch/model_32910e4.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/arch/pagemodel.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/arch/pagemodel_8be1499.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/utils/utils.js",
                "common:widget/ui/base/events.js", "common:widget/ui/arch/model.js"
            ]
        },
        "common:widget/ui/base/subject.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/base/subject_7c3c6c3.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/EventEmitter/EventEmitter.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/EventEmitter/EventEmitter_655344a.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/monitorRequest/monitorRequest.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/monitorRequest/monitorRequest_cabcf84.js",
            "pkg": "common:p1"
        },
        "common:widget/ui/searchUtils/searchUtils.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/searchUtils/searchUtils_17600ce.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/ui/slider/slider.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/slider/slider_545c0c2.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js",
                "common:widget/ui/EventEmitter/EventEmitter.js"
            ]
        },
        "common:widget/ui/statistic/statistic.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/statistic/statistic_09d1c4a.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js",
                "common:widget/ui/monitorRequest/monitorRequest.js",
                "common:widget/ui/base/events.js", "common:widget/ui/utils/utils.js"
            ]
        },
        "common:widget/ui/suggest/data.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/suggest/data_89dc815.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/utils/utils.js",
                "common:widget/ui/base/events.js"
            ]
        },
        "common:widget/ui/suggest/inputwatcher.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/suggest/inputwatcher_2eb7c40.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/events.js"]
        },
        "common:widget/ui/suggest/suggestionlist.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/suggest/suggestionlist_37c79c7.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/events.js"]
        },
        "common:widget/ui/suggest/suggestion.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/suggest/suggestion_1507f89.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/base/events.js",
                "common:widget/ui/suggest/data.js", "common:widget/ui/suggest/inputwatcher.js",
                "common:widget/ui/suggest/suggestionlist.js"
            ]
        },
        "common:widget/ui/sugHistory/sugHistory.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/sugHistory/sugHistory_4277c60.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/statistic/statistic.js",
                "common:widget/ui/utils/utils.js"
            ]
        },
        "common:widget/ui/SugRec/SugRec.js": {
            "url": "//img2.bdstatic.com/static/common/widget/ui/SugRec/SugRec_3755387.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/statistic/statistic.js"]
        },
        "common:widget/ui/swf/swf.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/swf/swf_b5294d0.js",
            "pkg": "common:p1"
        },
        "common:widget/ui/userInfo/userInfo.js": {
            "url": "//img1.bdstatic.com/static/common/widget/ui/userInfo/userInfo_4160d44.js",
            "pkg": "common:p1",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/searchUtils/searchUtils.js",
                "common:widget/ui/base/events.js", "common:widget/ui/utils/utils.js"
            ]
        },
        "common:widget/ui/feedback/feedback.js": {
            "url": "//img0.bdstatic.com/static/common/widget/ui/feedback/feedback_4002381.js",
            "pkg": "common:p1"
        },
        "common:widget/shitu/static/animate.js": {
            "url": "//img1.bdstatic.com/static/common/widget/shitu/static/animate_d5993fc.js",
            "deps": ["common:widget/ui/base/base.js"]
        },
        "common:widget/shitu/run.js": {
            "url": "//img0.bdstatic.com/static/common/widget/shitu/run_c4ee0ab.js",
            "deps": ["common:widget/ui/base/base.js", "common:widget/ui/utils/utils.js",
                "common:widget/shitu/static/animate.js"
            ]
        },
        "home:static/shitu/index.js": {
            "url": "//img1.bdstatic.com/static/home/shitu/index_ba03d37.js"
        }
    },
    "pkg": {
        "common:p1": {
            "url": "//img0.bdstatic.com/static/common/pkg/cores_b4aad57.js"
        }
    }
});