import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
    selector: "help",
    templateUrl: "./app/help.html"
})
export class help {
    public visFaq: boolean;
    public visSkjema: boolean;
    public adminSide: boolean;

    constructor() {
    }

    ngOnInit() {
        this.visFaq = true;
        this.visSkjema = false;
        this.adminSide = false;
    }

    visSkjemaView() {
        this.visFaq = false;
        this.visSkjema = true;
        this.adminSide = false;
    }

    visfaqs() {
        this.visFaq = true;
        this.visSkjema = false;
        this.adminSide = false;
    }
        
    visAdminSide() {
        this.visFaq = false;
        this.visSkjema = false;
        this.adminSide = true;
    }
}