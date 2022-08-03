import { City } from './city.model';
import { PersonLanguage } from './person-language.model';
export class Person
{
  constructor(public id?: number,
    public name?: string,
    public phoneNumber?: number,
    //public city: City,
    //public languages: PersonLanguage[]
  ) {

  }
}
