import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public userName: string;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(private router: Router, private authenticationService: AuthenticationService) {}

  ngOnInit() {
  }


  sair() {
    this.authenticationService.logout();
    this.router.navigate(["/Login"]);
  }
  
}
