"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var help = (function () {
    function help() {
    }
    help.prototype.ngOnInit = function () {
        this.visFaq = true;
        this.visSkjema = false;
        this.adminSide = false;
    };
    help.prototype.visSkjemaView = function () {
        this.visFaq = false;
        this.visSkjema = true;
        this.adminSide = false;
    };
    help.prototype.visfaqs = function () {
        this.visFaq = true;
        this.visSkjema = false;
        this.adminSide = false;
    };
    help.prototype.visAdminSide = function () {
        this.visFaq = false;
        this.visSkjema = false;
        this.adminSide = true;
    };
    return help;
}());
help = __decorate([
    core_1.Component({
        selector: "help",
        templateUrl: "./app/help.html"
    }),
    __metadata("design:paramtypes", [])
], help);
exports.help = help;
//# sourceMappingURL=help.js.map