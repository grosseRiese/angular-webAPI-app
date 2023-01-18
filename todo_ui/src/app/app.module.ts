import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {HttpClientModule} from '@angular/common/http';
import { AddTodoComponent } from './crud-components/Todos/add-todo/add-todo.component';
import { TodoListComponent } from './crud-components/Todos/todo-list/todo-list.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { EditTodoComponent } from './crud-components/Todos/edit-todo/edit-todo.component';
import { ItemDetailsComponent } from './crud-components/Todos/item-details/item-details.component';
import { MyInfoComponent } from './crud-components/Todos/my-info/my-info.component';
import { QRCodeModule } from 'angular2-qrcode';
import { NotFoundComponent } from './crud-components/Errors/not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    AddTodoComponent,
    TodoListComponent,
    EditTodoComponent,
    ItemDetailsComponent,
    MyInfoComponent,
    NotFoundComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    QRCodeModule,
  /*******************************
   *   RouterModule.forRoot([
      {path: 'app-todo-list', component: TodoListComponent},
      {path: 'app-add-todo', component: AddTodoComponent},
    ]),
   */
    
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
