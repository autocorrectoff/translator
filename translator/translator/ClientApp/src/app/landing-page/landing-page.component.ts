import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { TranslatorBackendService } from '../services/translator-backend.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/';
import { fromEvent } from 'rxjs/observable/fromEvent';
import { debounceTime, take } from 'rxjs/operators';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit, AfterViewInit {
  @ViewChild('input')
  input: ElementRef;

  inputObservable: Observable<any>;

  text = '';

  word: string;

  constructor(private translator: TranslatorBackendService, private router: Router) {}

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    this.inputObservable = fromEvent(
              this.input.nativeElement, 'keyup');
  }

  goToResultPage(word: string) {
    this.router.navigate(['result-page'], {queryParams: {from: word}});
  }

  onKeyPress(val: string) {
    this.inputObservable.pipe(debounceTime(3000), take(1)).subscribe(res => {
        this.translator.getByWord(this.word).pipe(take(1)).subscribe(result => {
          this.text = result.to;
        }, err => {
          this.text = err.error.text;
        });
    });
  }
}
