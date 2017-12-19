"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var help_1 = require("./help");
var kontaktskjema_1 = require("./kontaktskjema");
var faqs_1 = require("./faqs");
var adminside_1 = require("./adminside");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, http_1.HttpModule, forms_1.ReactiveFormsModule, http_1.JsonpModule],
        declarations: [help_1.help, faqs_1.faqs, kontaktskjema_1.kontaktskjema, adminside_1.adminside],
        bootstrap: [help_1.help],
    })
], AppModule);
exports.AppModule = AppModule;
//@NgModule({
//    imports: [BrowserModule, HttpModule, ReactiveFormsModule, JsonpModule],
//    declarations: [adminside],
//    bootstrap: [adminside],
//})
//export class AdminsideModule { }
//# sourceMappingURL=app.module.js.map