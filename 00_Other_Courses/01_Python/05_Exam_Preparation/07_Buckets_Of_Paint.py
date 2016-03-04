import sys

def encrypt(text, shift):
    caesar_key = shift
    caesar_message = text

    actual_message = ''

    for ch in caesar_message:
        ch_ascii = ord(ch)

        if(ch.isupper()):
            ch_ascii-=65
            ch_ascii+=caesar_key
            ch_ascii%=26
            ch_ascii+=65
        elif(ch.islower()):
            ch_ascii-=97
            ch_ascii+=caesar_key
            ch_ascii%=26
            ch_ascii+=97
        actual_message+=chr(ch_ascii)
    return actual_message

def main():
    caesar_key = input()
    caesar_message = input()
    try:
        print(encrypt(caesar_message,int(caesar_key)))
    except(Exception):
        print('INVALID INPUT')
if __name__ == '__main__':
    sys.exit(main())