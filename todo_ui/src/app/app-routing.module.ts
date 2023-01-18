import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTodoComponent } from './crud-components/Todos/add-todo/add-todo.component';
import { EditTodoComponent } from './crud-components/Todos/edit-todo/edit-todo.component';
import { TodoListComponent } from './crud-components/Todos/todo-list/todo-list.component';
import { ItemDetailsComponent } from './crud-components/Todos/item-details/item-details.component';
import { MyInfoComponent } from './crud-components/Todos/my-info/my-info.component';
import { NotFoundComponent } from './crud-components/Errors/not-found/not-found.component';
const routes: Routes = [
   //{
  //  path: '',
  //  component:TodoListComponent
  //},
  {
    path: '',
    redirectTo:'todo',
    pathMatch:'full'
  },
  {
    path:"todo",
    component:TodoListComponent
  },
  {
    path:"todo/add",
    component:AddTodoComponent
  },
  {
    path:"todos/edit/:id",
    component:EditTodoComponent
  },
  {
    path:"todos/:id",
    component:ItemDetailsComponent
  },
  {path:"myInfo",component:MyInfoComponent},
  {
    path:"**",
    component:NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
