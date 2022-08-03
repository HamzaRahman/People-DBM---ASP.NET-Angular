import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Person } from "../models/person.model";
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  http: HttpClient;
  baseUrl: string;
  public people: Person[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  getPeople() {
    return this.http.get<Person[]>(this.baseUrl + 'person')
  }
}
