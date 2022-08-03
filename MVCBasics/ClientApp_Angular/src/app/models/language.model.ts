import { PersonLanguage } from "./person-language.model";
export class Language
{
  constructor(
    public id: number,
    public name: string,
    public people: PersonLanguage[]) {

  }
}
