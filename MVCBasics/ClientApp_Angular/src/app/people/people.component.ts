import { Component, OnInit, Inject } from '@angular/core';
import { Person } from "../person.model";
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
    //this.people.push({ id: 1, name: "Hamza", phoneNumber: 304 })
    http.get<Person[]>(baseUrl + 'person').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
    for (let person of this.people) {
      console.log(person.id);
    }
  }

  ngOnInit(): void
  {
  }

}

