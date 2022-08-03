import { Component, OnInit, Inject } from '@angular/core';
import { Person } from "../person.model";
import { HttpClient } from '@angular/common/http';
import { PeopleService } from '../people.service';
@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {
  public people: Person[] = [];

  constructor(pservice: PeopleService)
  {
    pservice.getPeople().subscribe(result => { this.people = result; });
    for (let person of this.people)
    {
      console.log(person.id);
    }
  }

  ngOnInit(): void
  {
  }

}

