import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { ToDo } from '../models/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodosService {
  baseUrl:string = environment.baseApiUrl;
  
  constructor(private http:HttpClient) { }
   //Get all todos
  getAllTodos() {
    return this.http.get<ToDo[]>(this.baseUrl+'/api/ToDo');
  }
  //add new todo
  addNewTodo(addTodoRequest:ToDo):Observable<ToDo>{
    addTodoRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<ToDo>(this.baseUrl+'/api/ToDo', addTodoRequest);
  }
  //Edit a todo
  getTodo(id:string):Observable<ToDo>{
    return this.http.get<ToDo>(this.baseUrl+'/api/ToDo/' + id);
  }
  //Update a todo
  updateChoosenTodo(id:string,updateTodoRequest:ToDo):Observable<ToDo>{
    return this.http.put<ToDo>(this.baseUrl+'/api/ToDo/' + id,updateTodoRequest);
  }
  //Delete an todo
  deleteChoosenTodo(id:string):Observable<ToDo>{
    return this.http.delete<ToDo>(this.baseUrl+'/api/ToDo/' + id);
  }

}
