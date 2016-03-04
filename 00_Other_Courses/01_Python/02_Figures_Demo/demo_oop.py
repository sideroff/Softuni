import sys
import json
import turtle
from typing import List, Dict

from figures.base import Figure
from figures.simple import *

FIGURE_TYPES = {
    "circle": Circle,
    "square": Square,
    "rectangle": Rectangle,
    "polygon": Polygon,
}

def main():
    if len(sys.argv) < 2:
        print("Usage: {} input-file.json".format(sys.argv[0]))
        return 1

    try:
        input_data = load_input_data(sys.argv[1])
        figures = create_figures(input_data)
        draw_figures(figures)
    except Exception as e:
        print("Invalid input file provided! Error: " + str(e))
        return 2

def load_input_data(input_filename):
    with open(input_filename) as f:
        input_data = json.load(f)
        return input_data

def create_figures(input_data: dict) -> List[Figure]:
    result = []
    for f_info in input_data:
        figure_type = f_info['type']
        if figure_type in FIGURE_TYPES:
            figure_class = FIGURE_TYPES[figure_type]
            result.append(figure_class(**f_info))
        else:
            raise ValueError("Unsupported figure")
    return result

def draw_figures(figures: List[Figure]):
    for figure in figures:
        t = turtle.Turtle()
        t.speed('slow')
        figure.draw(t)
    turtle.exitonclick()

if __name__ == "__main__":
    sys.exit(main())