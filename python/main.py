import hashlib as hasher

class dilKontrol:
  def __init__(self,cumleler,kelimeler,girdi): 
    self.cumleler= cumleler
    self.kelimeler=kelimeler
    self.girdi = girdi
 
  def cumleAyir(self,girdi):
    cumleler=girdi.split(". ")
    return cumleler

  def sayiBul(self,dizi):
    return len(dizi)

  def kelimeAyir(self,girdi):
    kelimeler=girdi.split()
    return kelimeler  

  def sesliHarfSayisi(self,girdi):
    i = 0
    sesli = 'AEIİOÖUÜaeıioöuü'
    for x in girdi:
      if x in sesli:
        i +=1
    return i

  def buyukUnluUyumu(self,girdi):
    kalin_unluler = list("aıou")
    ince_unluler = list("eiöü")
    uyan,uymayan =0,0
    for x in girdi:
      if (sum(x.count(kalin) for kalin in kalin_unluler)) != 0 and (sum(x.count(ince) for ince in ince_unluler)) != 0:
        uymayan+=1
      else:
        uyan+=1
    return uyan,uymayan


class sifrelemeYontemleri:
  def __init__(self,girdi): 
    self.girdi = girdi

  def SHA256_Hash(self,girdi):
    sifreleyici = hasher.sha256()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash
  
  def MD5_Hash(self,girdi):
    sifreleyici=hasher.md5()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash

  def SHA224_Hash(self,girdi):
    sifreleyici=hasher.sha224()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash

  def SHA384_Hash(self,girdi):
    sifreleyici=hasher.sha384()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash

  def SHA512_Hash(self,girdi):
    sifreleyici=hasher.sha512()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash

  def SHA1_Hash(self,girdi):
    sifreleyici=hasher.sha1()
    sifreleyici.update(girdi.encode("utf-8"))
    hash = sifreleyici.hexdigest()
    return hash

  def Sezar(self,girdi):
    key = int(input("1-10 arasında anahtar değeri giriniz: "))
    translated = ""
    for letter in girdi:
        if letter.isalpha():
            newLetter = ord(letter)
            newLetter += key
            if letter.isupper():
                if newLetter > ord("Z"):
                    newLetter -= 26
                elif newLetter < ord("A"):
                    newLetter += 26
            elif letter.islower():
                if newLetter > ord("z"):
                    newLetter -= 26
                elif newLetter < ord("a"):
                    newLetter += 26
            translated +=chr(newLetter)
        else:
            translated+=letter
    return translated

  def ROT13(self,girdi):
    rot13trans = str.maketrans('ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz','NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm')
    return girdi.translate(rot13trans)



class HelpSinifi:
  def __init__(self,girdi):
    self.girdi = girdi
    
  def modulYazdir(self,girdi):
    #print("{} string ifadesi için tanımlanan özellikler:",girdi)
    print("\nDil kontrol sınıfı içerisinde yazım kuralları kontrolü yapılmaktadır. Sınıf içerisinde 5 farklı fonksiyon bulunmaktadır.\n ") 
    print("*cumleAyir fonksiyonu girilen metni '.' ya göre cümlelerine ayırır.\n*kelimeAyir fonksiyonu girilen metnin içindeki kelimeleri ayırır.\n*sayiBul fonksiyonu ayrılan kelime ve cümlelerin ayrı ayrı sayılarını bulur.\n*sesliHarfSayisi fonksiyonu girilen metinde kaç adet sesli harf olduğunu bulur.\n*buyukUnluUyumu fonksiyonu girilen metnin içinde kaç kelimenin büyük ünlü uyumuna uyduğunu kaç kelimenin uymadiğini gösterir.") 
    print("\nŞifreleme yöntemleri sınıfı içerisinde 8 fonksiyon bulunmaktadır. 6 fonksiyon hash şifreleme algoritması, 2 fonksiyon simetrik şifreleme algoritmasıdır.\n")
    print("Hash şifreleme algoritmaları: SHA256, SHA384, SHA512, SHA224, SHA1, MD5\nSimetrik şifreleme algoritmaları: Sezar Şifreleme Algoritması, Rot13 Algoritması\n")




metin= input("Cümle yazın \n")
DK = dilKontrol("","",metin)
SY = sifrelemeYontemleri(metin)
H = HelpSinifi(metin)

#help dökümanı çağırma
H.modulYazdir(metin)

#cumlelere ayırma
print("cümle ayır:")
cumleler = DK.cumleAyir(metin)
print(cumleler)
print("cumle sayısı:",DK.sayiBul(cumleler))

#kelimelere ayırma
print( "kelime ayır.")
kelimeler = DK.kelimeAyir(metin)
print(kelimeler)
print("kelime sayısı:",DK.sayiBul(kelimeler))

#sesli harf sayısı bulma
print("sesli harf sayısı:",DK.sesliHarfSayisi(metin))

#büyük ünlü uyumu kontrolü
uyan,uymayan = DK.buyukUnluUyumu(kelimeler)
print("uyan:",uyan)
print("uymayan:",uymayan)

#hash 
print("\nSHA256:",SY.SHA256_Hash(metin))
print("\nSHA384:",SY.SHA384_Hash(metin)) 
print("\nSHA512:",SY.SHA512_Hash(metin)) 
print("\nSHA1:",SY.SHA1_Hash(metin))
print("\nSHA224:",SY.SHA224_Hash(metin))
print("\nMD5:",SY.MD5_Hash(metin))

#simetrik algoritmaları
#sezar
a=SY.Sezar(metin)
print("SEZAR:",a)
#rot13
b=SY.ROT13(metin)
print("\nROT13:",b)


