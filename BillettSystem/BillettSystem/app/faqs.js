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
var faqs = (function () {
    function faqs(httpParameter) {
        this._minhttp = httpParameter;
    }
    faqs.prototype.ngOnInit = function () {
        var _this = this;
        this.heading = "Hva kan vi hjelpe deg med?";
        this._minhttp.get("/api/Kategorier")
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            _this.kategoriListe = JsonData; // setter json liste i lokal variabel liste for å vise i gui            
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get-api/Kategorier"); });
    };
    //metode
    faqs.prototype.hentAlleFaQFraKategori = function (kategori) {
        var _this = this;
        this._minhttp.get("api/QuestionAnswers?kategori=" + kategori)
            .map(function (returData) {
            var JsonData = returData.json();
            return JsonData;
        })
            .subscribe(function (JsonData) {
            console.log(JsonData); //testing result
            _this.selectedfaqs = JsonData;
        }, function (error) { return alert(error); }, function () { return console.log("ferdig get-api/QuestionAnswers"); });
    };
    return faqs;
}());
faqs = __decorate([
    core_1.Component({
        selector: 'faqs',
        templateUrl: './app/faqs.html'
    }),
    __metadata("design:paramtypes", [http_1.Http])
], faqs);
exports.faqs = faqs;
var questionAnswer = (function () {
    function questionAnswer() {
    }
    return questionAnswer;
}());
exports.questionAnswer = questionAnswer;
//# sourceMappingURL=faqs.js.map