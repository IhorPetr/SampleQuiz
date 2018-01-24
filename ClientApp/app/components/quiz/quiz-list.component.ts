import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: "quiz-list",
    templateUrl: './quiz-list.component.html',
    styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent {
    private title: string;
    private selectedQuiz: Quiz;
    private quizzes: Quiz[];

    public constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.title = "Latest Quizzes";
        let url = baseUrl + "api/quiz/Latest/";
    }

    public onSelect(quiz: Quiz) {
        this.selectedQuiz = quiz;
        console.log("quiz with Id "
            + this.selectedQuiz.Id
            + " has been selected.");
    }
}