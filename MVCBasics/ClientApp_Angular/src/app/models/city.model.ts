import { Person } from "../people/models/person.model";
import { Country } from "./country.model";
export class City
{
  constructor(
    public id: number,
    public name: string,
    public country: Country,
    public people: Person[]) {

  }
}
