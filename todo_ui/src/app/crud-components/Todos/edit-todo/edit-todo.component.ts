import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToDo } from 'src/app/models/todo.model';
import { TodosService } from 'src/app/service/todos.service';

@Component({
  selector: 'app-edit-todo',
  templateUrl: './edit-todo.component.html',
  styleUrls: ['./edit-todo.component.css']
})
export class EditTodoComponent implements OnInit {
  todoDetailsAsObject:ToDo ={
    id:'',
    task:'',
    description:'',
    dueDate:'',
    isCompleted:false,
    toDoCategoryId:1,
  }
  constructor(private route:ActivatedRoute,private todoService:TodosService, private router:Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id = params.get('id');

        if(id){
          this.todoService.getTodo(id)
          .subscribe({
            next:(response)=>{
              this.todoDetailsAsObject = response;
            }
          });
        }

      }
    })

  }

  updateTodo(){
    this.todoService.updateChoosenTodo(this.todoDetailsAsObject.id,this.todoDetailsAsObject)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['todo'] );
        //console.log(response);
      }
    })
  }

 //deleteTodo(id:string){
 //  this.todoService.deleteChoosenTodo(id)
 //  .subscribe({
 //    next:(response)=>{
 //      this.router.navigate(['todo']);
 //    }
 //  });
 //}


}
