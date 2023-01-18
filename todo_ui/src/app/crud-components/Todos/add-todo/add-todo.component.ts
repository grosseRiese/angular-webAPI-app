import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToDo } from 'src/app/models/todo.model';
import { TodosService } from 'src/app/service/todos.service';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrls: ['./add-todo.component.css']
})
export class AddTodoComponent implements OnInit {
  addTodoRequest:ToDo ={
    id:'',
    task:'',
    description:'',
    dueDate:'',
    isCompleted:false,
    toDoCategoryId:1,
  }
  constructor(private todoService:TodosService, private router:Router) { }

  ngOnInit(): void {
  }
  addTodo(){
    this.todoService.addNewTodo(this.addTodoRequest)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['todo'] );
        //console.log(response);
      }
    })
  }

  
}
