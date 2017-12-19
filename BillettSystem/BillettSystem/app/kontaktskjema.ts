import { Component } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Http, Headers } from "@angular/http";
import { KundeQuestion } from "./Types/KundeQuestion";

@Component({
    selector: 'kontaktskjema',
    templateUrl: './app/kontaktskjema.html'
})
export class kontaktskjema {
    public skjema: FormGroup;
    public visSkjema: boolean;
    public kategorier: Array<string>;
    public kategori: string;
    public navn: string;
    public questionTitle: string;
    public questionText: string;
    public epost: string;
    public questionSendt = false;

    constructor(private _http: Http, private fb: FormBuilder) {
        this.kategorier = ["Bestilling", "Søking", "Reise", "Priser"];
        this.skjema = fb.group({
            kategori: ['', Validators.required],
            navn: [null, Validators.compose([Validators.required, Validators.pattern("[ a-zA-ZøæåØÆÅ\\-.]{2,50}")])],            
            epost: [null, Validators.compose([Validators.required, Validators.pattern(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)])],
            questionTitle: [null, Validators.compose([Validators.required, Validators.minLength(5)])],
            questionText: [null, Validators.compose([Validators.required, Validators.minLength(5)])],
        });
    }    

    vedSubmit() {
        this.lagreKundeQuestion();
        
    }

    lagreKundeQuestion() {
        let kundeQuestion = new KundeQuestion();
        kundeQuestion.Kategori = this.skjema.value.kategori;
        kundeQuestion.Brukernavn = this.skjema.value.navn;
        kundeQuestion.QuestionTittel = this.skjema.value.questionTitle;
        kundeQuestion.Epost = this.skjema.value.epost;
        kundeQuestion.QuestionText = this.skjema.value.questionText;

        var body: string = JSON.stringify(kundeQuestion);
        var headers = new Headers({ "Content-Type": "application/json" });
        
        this._http.post("api/KundeQuestions", body, { headers: headers })
            .map(returData => returData.toString())
            .subscribe(
            retur => {
                this.questionSendt = true;
                this.skjema.reset();
            },
            error => alert(error),
            () => console.log("ferdig post-api/KundeQuestions"));
    };
}

