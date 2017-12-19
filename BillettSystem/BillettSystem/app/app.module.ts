import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { help } from './help';
import { kontaktskjema } from './kontaktskjema';
import { faqs } from './faqs';
import { adminside } from './adminside';

@NgModule({
    imports: [BrowserModule, HttpModule, ReactiveFormsModule, JsonpModule], 
    declarations: [help, faqs, kontaktskjema, adminside],
    bootstrap: [help],
})
export class AppModule { }

//@NgModule({
//    imports: [BrowserModule, HttpModule, ReactiveFormsModule, JsonpModule],
//    declarations: [adminside],
//    bootstrap: [adminside],
//})
//export class AdminsideModule { }
