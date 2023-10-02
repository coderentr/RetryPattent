### Retry Pattern

Servisler arası iletişim kurduğumuz noktalarda istekte bulunulan servisin herhengi bir nedenden dolayı cevap vermediği yada hata döndüğü
durumlarda isteği tekrarlamak, timeout işlemleri yada bağlantısını kesmek, sınırlandırmak isteyebiliriz. İşte bu gereksinim doğrultusunda
.net de retry patten'i polly kütüphanesinden faydalanarak kullanabiliriz.

Geçici ağ sorunları yada hizmet kesintileri olması durumunda sistemimize aşırı yüklenmeden sorunu çözmüş olabiliriz. 


