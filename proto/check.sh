#!/bin/bash

mkdir -p /tmp/proto_generated
find . -name "*.proto" -exec protoc -I. --java_out=/tmp/proto_generated {} +
rm -rf /tmp/proto_generated
