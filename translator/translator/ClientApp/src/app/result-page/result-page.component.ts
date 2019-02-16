import { TranslatorBackendService } from './../services/translator-backend.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.css']
})
export class ResultPageComponent implements OnInit {
  result = '';
  constructor(private route: ActivatedRoute, private translator: TranslatorBackendService) { }

  ngOnInit() {
    const word = this.route.snapshot.queryParams['from'];
    this.translator.postWord({word: word}).subscribe(res => {
        this.result = res.to;
    }, err => {
      this.result = err.error;
      console.log(err);
    });
  }

}
