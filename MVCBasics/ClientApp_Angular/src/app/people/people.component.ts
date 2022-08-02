import { Component, OnInit, Inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {
  public people: Person[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    //this.people.push({ ID: 1, Name: "Hamza", PhoneNumber: 304 })
    http.get<Person[]>(baseUrl + 'person').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }

  ngOnInit(): void
  {
  }

}
class Person
{
  constructor(public id: number,
    public name: string,
    public phoneNumber: number,
    public City: City,
    public languages: PersonLanguage[]
  )
  {

  }
}
class PersonLanguage
{
  constructor(
    public ID: number,
    public PersonID: number,
    public Person: Person,
    public LanguageID: number,
    public Language: Language)
  {

  }
}
class Language
{
  constructor(
    public ID: number,
    public Name: string,
    public People: PersonLanguage[]) {

  }
}
class City
{
  constructor(
    public ID: number,
    public Name: string,
    public Country: Country,
    public People: Person[])
  {

  }
}
class Country
{
  constructor(
    public ID: number,
    public Name: string,
    public Cities: City[])
  {

  }
}
