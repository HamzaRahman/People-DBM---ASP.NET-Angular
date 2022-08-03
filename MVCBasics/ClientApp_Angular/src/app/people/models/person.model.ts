import { City } from 'src/app/models/city.model';
import { PersonLanguage } from 'src/app/models/person-language.model';
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
