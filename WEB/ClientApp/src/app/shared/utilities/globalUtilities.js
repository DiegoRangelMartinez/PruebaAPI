"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GlobalUtilities = void 0;
var GlobalUtilities = /** @class */ (function () {
    function GlobalUtilities() {
    }
    GlobalUtilities.prototype.getApiUrl = function (api) {
        return window.location.origin.replace(":44306", ":44327") + "/" + api;
    };
    return GlobalUtilities;
}());
exports.GlobalUtilities = GlobalUtilities;
//# sourceMappingURL=globalUtilities.js.map