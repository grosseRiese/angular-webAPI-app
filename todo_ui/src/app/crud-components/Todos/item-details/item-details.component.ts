import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToDo } from 'src/app/models/todo.model';
import { TodosService } from 'src/app/service/todos.service';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {
  singleTodoItem:ToDo ={
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
              this.singleTodoItem = response;
              console.log('Item: ',response);
            }
          });
        }

      }
    })
  }

  deleteTodo(id:string){
    this.todoService.deleteChoosenTodo(id)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['todo']);
      }
    });

  }

}
