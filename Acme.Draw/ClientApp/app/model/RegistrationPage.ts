import { IRegistration } from "./IRegistration"
import { IRegistrationPage } from "./IRegistrationPage"

export class RegistrationPage implements IRegistrationPage {
   
    rows: IRegistration[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
}