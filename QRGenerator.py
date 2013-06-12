__author__ = 'omockler'

import qrcode

url = 'http://mouseandlionale.com/beers/'

f = open('src/bin/Debug/qrs/qrList.txt')
fileContents = f.read()
names = fileContents.split( )

for name in names:
    code = qrcode.make(url + name + '/')
    code.save('src/bin/Debug/qrs/' + name+'.jpeg')
    print 'Code generated for: ' + name
