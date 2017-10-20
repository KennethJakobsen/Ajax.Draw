import { IRegistration } from "./IRegistration"

export interface IRegistrationPage {
    rows: IRegistration[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
}