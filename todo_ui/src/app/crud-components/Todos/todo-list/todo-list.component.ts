import { Component, EventEmitter, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { ToDo } from 'src/app/models/todo.model';
import { TodosService } from 'src/app/service/todos.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  todoList:ToDo[]=[];
  
  countCompleh:number=0;
  countImportant:number=0;
  countDeleted:number=0;

  constructor(private todoService:TodosService,private router:Router) { }

  ngOnInit(): void {
    
    this.todoService.getAllTodos()
    .subscribe({
      next:(response)=>{
        this.todoList= response;
        //console.log(response);
        this.increaseCounterCategory(response);
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }

  deleteTodo(id:string){
    this.todoService.deleteChoosenTodo(id)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['todo']);
        const todo = this.todoList.find(s => s.id === id);
        const index = this.todoList.findIndex((todo: any) => todo.id === id);
        if (index !== -1) this.todoList.splice(index, 1);
      }
    });
  }
  //Count completed todos
  countTodos(){
    return this.todoList.length;
  }

  increaseCounterCategory(res:ToDo[]){
    res.forEach(item => {
        item.toDoCategoryId == 1 ?
        this.countImportant++ : item.toDoCategoryId == 2 ?
        this.countCompleh++ : this.countDeleted++   })
  }


}
