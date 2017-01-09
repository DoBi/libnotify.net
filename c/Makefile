CC=gcc
CFLAGS=-pthread -I/usr/include/gdk-pixbuf-2.0 -I/usr/include/libpng12 -I/usr/include/glib-2.0 -I/usr/lib/x86_64-linux-gnu/glib-2.0/include -lnotify -lgdk_pixbuf-2.0 -lgio-2.0 -lgobject-2.0 -lglib-2.0 -fPIC

all: libnotify_net_wrapper.so

libnotify_net_wrapper.a: notification.c
	$(CC) -o libnotify_net_wrapper.a -c notification.c $(CFLAGS)
	
libnotify_net_wrapper.so: libnotify_net_wrapper.a
	$(CC) -shared -o libnotify_net_wrapper.so libnotify_net_wrapper.a

clean:
	rm libnotify_net_wrapper.so libnotify_net_wrapper.a

install: all
	cp -v libnotify_net_wrapper.a /usr/lib/x86_64-linux-gnu/
	cp -v libnotify_net_wrapper.so /usr/lib/x86_64-linux-gnu/