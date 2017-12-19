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
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var KundeQuestion_1 = require("./Types/KundeQuestion");
var kontaktskjema = (function () {
    function kontaktskjema(_http, fb) {
        this._http = _http;
        this.fb = fb;
        this.questionSendt = false;
        this.kategorier = ["Bestilling", "Søking", "Reise", "Priser"];
        this.skjema = fb.group({
            kategori: ['', forms_1.Validators.required],
            navn: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern("[ a-zA-ZøæåØÆÅ\\-.]{2,50}")])],
            epost: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.pattern(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)])],
            questionTitle: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(5)])],
            questionText: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(5)])],
        });
    }
    kontaktskjema.prototype.vedSubmit = function () {
        this.lagreKundeQuestion();
    };
    kontaktskjema.prototype.lagreKundeQuestion = function () {
        var _this = this;
        var kundeQuestion = new KundeQuestion_1.KundeQuestion();
        kundeQuestion.Kategori = this.skjema.value.kategori;
        kundeQuestion.Brukernavn = this.skjema.value.navn;
        kundeQuestion.QuestionTittel = this.skjema.value.questionTitle;
        kundeQuestion.Epost = this.skjema.value.epost;
        kundeQuestion.QuestionText = this.skjema.value.questionText;
        var body = JSON.stringify(kundeQuestion);
        var headers = new http_1.Headers({ "Content-Type": "application/json" });
        this._http.post("api/KundeQuestions", body, { headers: headers })
            .map(function (returData) { return returData.toString(); })
            .subscribe(function (retur) {
            _this.questionSendt = true;
            _this.skjema.reset();
        }, function (error) { return alert(error); }, function () { return console.log("ferdig post-api/KundeQuestions"); });
    };
    ;
    return kontaktskjema;
}());
kontaktskjema = __decorate([
    core_1.Component({
        selector: 'kontaktskjema',
        templateUrl: './app/kontaktskjema.html'
    }),
    __metadata("design:paramtypes", [http_1.Http, forms_1.FormBuilder])
], kontaktskjema);
exports.kontaktskjema = kontaktskjema;
//# sourceMappingURL=kontaktskjema.js.map