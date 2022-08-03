import { City } from "./city.model";
export class Country
{
  constructor(
    public id: number,
    public name: string,
    public cities: City[]) {

  }
}
