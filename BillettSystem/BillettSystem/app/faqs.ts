import { Component, OnInit } from "@angular/core";
import { Http} from "@angular/http";
import "rxjs/add/operator/map"; //huske å inkludere alle importer som skal brukes

@Component({
    selector: 'faqs',
    templateUrl: './app/faqs.html'
})
export class faqs {
    public heading: string;
    public kategoriListe: string[];
    public selectedfaqs: questionAnswer[];
    private _minhttp: Http;


    constructor(httpParameter: Http) {
        this._minhttp = httpParameter;
    }

    ngOnInit() {
        this.heading = "Hva kan vi hjelpe deg med?";

        this._minhttp.get("/api/Kategorier")
            .map(returData => {  //mapper API resultat til en lokal json type variabel 
                let JsonData = returData.json();
                return JsonData;
            })
            .subscribe(
            JsonData => {
                this.kategoriListe = JsonData; // setter json liste i lokal variabel liste for å vise i gui            
            },
            error => alert(error),
            () => console.log("ferdig get-api/Kategorier"));        
    }

    //metode
    hentAlleFaQFraKategori(kategori: string) {        
        this._minhttp.get("api/QuestionAnswers?kategori=" + kategori)
            .map(returData => {
                let JsonData = returData.json();                
                return JsonData;
            })
            .subscribe(
            JsonData => {
                console.log(JsonData); //testing result
                this.selectedfaqs = JsonData;               
            },
            error => alert(error),
            () => console.log("ferdig get-api/QuestionAnswers"));
    }
}

export class questionAnswer {
    Id: number;
    Kategori: string;
    Question: string;
    Svar: string;
}