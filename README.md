BsmxToMd
========

Convert Beer Smith 2 recipes to markdown for publishing

The .net library I found to output QR codes doesn't seem to work in Mono so that part is implemented in python.

Uses the library [python-qrcode](https://github.com/lincolnloop/python-qrcode) to generate QR codes

Qr codes also require Python Image Library
Right now it only works for recipes named similarly to my normal naming convention. (001 - Pale Ale, or 036 - Oud Bruin)
