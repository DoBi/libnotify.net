#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([libnotify_net_wrapper], [0.0.1], [https://github.com/DoBi/libnotify.net])
AC_CONFIG_SRCDIR([notification.h])

# Checks for programs.
AC_PROG_CC

dnl Testing presence of pkg-config
AC_MSG_CHECKING([pkg-config m4 macros])
if test m4_ifdef([PKG_CHECK_MODULES], [yes], [no]) == yes; then
	AC_MSG_RESULT([yes]);
else
	AC_MSG_RESULT([no]);
	AC_MSG_ERROR([pkg-config is required. See pkg-config.freedesktop.org])
fi

# Checks for libraries.
PKG_CHECK_MODULES([GLIB], [glib-2.0])
PKG_CHECK_MODULES([libnotify], [libnotify])

AC_CONFIG_FILES([Makefile])
AC_OUTPUT
