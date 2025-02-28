import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {PublicRoutingModule} from './public-routing.module';
import {AboutComponent} from './about/about.component';
import {BlogComponent} from './blog/blog.component';
import {ContactUsComponent} from './contact-us/contact-us.component';
import {HomeComponent} from './home/home.component';
import {PublicLayoutComponent} from './public-layout/public-layout.component';
import {TravelsComponent} from './travels/travels.component';
import {FormsModule} from '@angular/forms';
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatDatepicker, MatDatepickerInput, MatDatepickerToggle} from '@angular/material/datepicker';
import {MatIcon} from '@angular/material/icon';
import {MatInput} from '@angular/material/input';
import {MatFabButton} from '@angular/material/button';
import {MatList, MatListItem} from "@angular/material/list";
import {MatDivider} from '@angular/material/divider';
import {MatCard} from '@angular/material/card';
import {MatAutocomplete, MatAutocompleteTrigger, MatOption} from "@angular/material/autocomplete";

@NgModule({
  declarations: [
    AboutComponent,
    BlogComponent,
    ContactUsComponent,
    HomeComponent,
    PublicLayoutComponent,
    TravelsComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    FormsModule,
    MatLabel,
    MatFormField,
    MatDatepickerToggle,
    MatDatepicker,
    MatDatepickerInput,
    MatIcon,
    MatInput,
    MatFabButton,
    MatList,
    MatListItem,
    MatDivider,
    MatCard,
    MatAutocompleteTrigger,
    MatAutocomplete,
    MatOption
  ],

})
export class PublicModule {
}
