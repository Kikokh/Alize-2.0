import { Component } from '@angular/core';

@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.scss']
})
export class ChartsComponent {
  dailyEvolution = [
    {
      "name": "g de CO2",
      "series": [
        {
          "name": 0.0,
          "value": 0
        },
        {
          "name": 0.8,
          "value": 0
        },
        {
          "name": 1.0,
          "value": 0
        },
        {
          "name": 1.2,
          "value": 15
        },
        {
          "name": 2.0,
          "value": 0
        },
        {
          "name": 3,
          "value": 0
        },
        {
          "name": 5,
          "value": 0
        },
        {
          "name": 10,
          "value": 0
        },
        {
          "name": 11,
          "value": 15
        },
        {
          "name": 13,
          "value": 10
        },
        {
          "name": 20,
          "value": 0
        }
      ]
    }
  ]

  carbonPerDay = [
    {
      "name": "Lunes",
      "value": 0
    },
    {
      "name": "Martes",
      "value": 0
    },
    {
      "name": "Miercoles",
      "value": 7000
    },
    {
      "name": "Jueves",
      "value": 15000
    },
    {
      "name": "Viernes",
      "value": 10000
    },
    {
      "name": "Sábado",
      "value": 2000
    },
    {
      "name": "Domingo",
      "value": 0
    }
  ]
  
  carbonPerWeek = [
    {
      "name": "37",
      "value": 8000
    },
    {
      "name": "38",
      "value": 10000
    },
    {
      "name": "39",
      "value": 9000
    },
    {
      "name": "40",
      "value": 12000
    },
    {
      "name": "41",
      "value": 9000
    },
    {
      "name": "42",
      "value": 7000
    },
    {
      "name": "43",
      "value": 5000
    }
  ]

  constructor(
  ) { }
}
