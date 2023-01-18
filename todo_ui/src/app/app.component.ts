import { Component, OnInit} from '@angular/core';
import { TodosService } from './service/todos.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'todo_ui';

  constructor() {
  }
  ngOnInit(): void {
  }
}