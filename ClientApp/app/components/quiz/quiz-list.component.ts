import { Component, Inject,Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: "quiz-list",
    templateUrl: './quiz-list.component.html',
    styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent {
    @Input() class: string;
    private title: string;
    private selectedQuiz: Quiz;
    private quizzes: Quiz[];

    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.title = "Latest Quizzes";
        let url = baseUrl + "api/quiz/";

        switch(this.class) {
            case "latest":
            default:
                this.title = "Latest Quizzes";
                url += "Latest/";
                break;
            case "byTitle":
                this.title = "Quizzes by Title";
                url += "ByTitle/";
                break;
            case "random":
                this.title = "Random Quizzes";
                url += "Random/";
                break;
        }

        this.http.get<Quiz[]>(url).subscribe(result => {
                this.quizzes = result;
            },
            error => console.error(error));
    }

    public onSelect(quiz: Quiz) {
        this.selectedQuiz = quiz;
        console.log("quiz with Id "
            + this.selectedQuiz.Id
            + " has been selected.");
    }
}