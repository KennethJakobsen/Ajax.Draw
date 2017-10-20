import { Component, OnInit } from '@angular/core';
import { NG_VALIDATORS, Validator, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { RegistrationRequest } from "../../model/RegistrationRequest"
import { RegistrationService } from "../../services/registration.service"
import { SerialService } from "../../services/serial.service"

@Component({
    selector: 'serialinput',
    templateUrl: './serialinput.component.html',
    styleUrls: ['./serialinput.component.css']
})
export class Serialinput implements OnInit {
    statusType = SerialStatus;
    registration = new RegistrationRequest();
    registrationAccepted: boolean = false;
    serialStatus: SerialStatus = SerialStatus.Initial;
    constructor(private regSvc: RegistrationService, private serialSvc: SerialService) { }

    ngOnInit() {
    }
    register() {
        this.regSvc.register(this.registration).subscribe((isOk: boolean) => {
            this.registrationAccepted = isOk;
        })
    }
    validateSerial() {
        this.serialSvc.isValid(this.registration.Serial).subscribe((isOk: boolean) => {
            if (isOk)
                this.serialStatus = SerialStatus.Valid;
            else
                this.serialStatus = SerialStatus.NotValid;
        })
    }
}
enum SerialStatus {
    Initial,
    Valid,
    NotValid
}
