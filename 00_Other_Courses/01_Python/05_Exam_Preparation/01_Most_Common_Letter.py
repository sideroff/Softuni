import sys
from collections import Counter

def main():
    input_string = input().strip(' ')
    if input_string:
        print(Counter(input_string).most_common(1)[0][0])
    else:
        print('INVALID INPUT')


if __name__ == '__main__':
    sys.exit(main())