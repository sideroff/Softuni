import os
import sys
import socket

def main():
    host = '149.62.201.94'
    port = 5000

    s=socket.socket()
    s.connect((host,port))

    message = input('input message: ')
    while message != 'quit':
        s.send(bytes(message, 'UTF-8'))
        data = s.recv(1024)
        print('received: ' + str(data))
        message = input('input message: ')
    s.close()

if __name__ == '__main__':
    sys.exit(main())