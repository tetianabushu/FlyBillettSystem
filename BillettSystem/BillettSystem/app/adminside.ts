import { Component, OnInit } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map"; //huske å inkludere alle importer som skal brukes
import { KundeQuestion } from "./Types/KundeQuestion";

@Component({
    selector: 'adminside',
    templateUrl: './app/adminside.html'
})
export class adminside {
    public listeFraSkjema: KundeQuestion[];
    public heading: string;
    public http: Http;
    public selectedKundeQuestion: KundeQuestion;

    constructor(httpParameter: Http) {
        this.http = httpParameter;
        this.selectedKundeQuestion = null;
    }
    ngOnInit()
    {
        this.heading = "Spørsmål fra kunder";
        this.http.get("/api/KundeQuestions")
            .map(returData => {
                let JsonData = returData.json();
                return JsonData;
            })
            .subscribe(JsonData =>
            {
                this.listeFraSkjema = JsonData;
            },
            error => alert(error),
                ()=>console.log("ferdig get api/KundeQuestions"));
        
    }

    openQuestionDetails(question: KundeQuestion)
    {
        this.selectedKundeQuestion = question;        
    }

}
