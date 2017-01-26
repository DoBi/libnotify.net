#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([libnotify_net_wrapper], [0.0.1], [https://github.com/DoBi/libnotify.net])
AC_CONFIG_SRCDIR([notification.h])

# Checks for programs.
AC_PROG_CC

# Checks for libraries.
PKG_CHECK_MODULES([GLIB], [glib-2.0])
PKG_CHECK_MODULES([libnotify], [libnotify])

AC_CONFIG_FILES([Makefile])
AC_OUTPUT
