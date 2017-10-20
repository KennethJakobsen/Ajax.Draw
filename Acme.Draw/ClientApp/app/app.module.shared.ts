import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { Serialinput } from "./components/serialinput/serialinput.component";
import { Listregistrations } from "./components/listregistrations/listregistrations.component"

import { RegistrationService } from "./services/registration.service"
import { SerialService } from "./services/serial.service"

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        Serialinput,
        Listregistrations
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'ProductRegistration', pathMatch: 'full' },
            { path: "ProductRegistration", component: Serialinput },
            { path: "listregistrations", component: Listregistrations },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [RegistrationService, SerialService],
})
export class AppModuleShared {
}
