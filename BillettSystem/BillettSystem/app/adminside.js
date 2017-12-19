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
var http_1 = require("@angular/http");
require("rxjs/add/operator/map"); //huske å inkludere alle importer som skal brukes
var adminside = (function () {
    function adminside(httpParameter) {
        this.http = httpParameter;
        this.selectedKundeQuestion = null;
    }
    adminside.prototype.ngOnInit = function () {
        var _this = this;
        this.heading = "Spørsmål fra kunder";
        this.http.get("/api/KundeQuestions")
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            _this.listeFraSkjema = JsonData;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get api/KundeQuestions"); });
    };
    adminside.prototype.openQuestionDetails = function (question) {
        this.selectedKundeQuestion = question;
    };
    return adminside;
}());
adminside = __decorate([
    core_1.Component({
        selector: 'adminside',
        templateUrl: './app/adminside.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], adminside);
exports.adminside = adminside;
//# sourceMappingURL=adminside.js.map