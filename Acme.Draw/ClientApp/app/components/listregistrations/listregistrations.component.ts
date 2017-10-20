import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../../services/registration.service'
import { IRegistrationPage } from '../../model/IRegistrationPage'
import { RegistrationPage } from '../../model/RegistrationPage'
import { Observable, BehaviorSubject } from 'rxjs';

@Component({
  selector: 'listregistrations',
  templateUrl: './listregistrations.component.html',
  styleUrls: ['./listregistrations.component.css']
})
export class Listregistrations implements OnInit {

    
    page: IRegistrationPage;
    constructor(private rSvc: RegistrationService) {

        rSvc.getCurrentPage().subscribe((page: RegistrationPage) => {
            this.page = page;
        })

    }
    previousPage() : void {
        this.rSvc.getPreviousPage().subscribe((page: RegistrationPage) => {
            this.page = page;
        })
    }
    nextPage(): void {
        this.rSvc.getNextPage().subscribe((page: RegistrationPage) => {
            this.page = page;
        })
    }
    get showNext(): boolean {
        return this.rSvc.canGoForward();
    }
    get showPrev(): boolean {
        return this.rSvc.canGoBack();
    }

  ngOnInit() {
  }

}
