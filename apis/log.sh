# 查询日志目录
ls -l ./App_Data/Logs/20230825

# 查询日志
grep -r "清尾" ./App_Data/Logs/

# 显示日志
cat ./App_Data/Logs/20230825/error-20230825.log.0
cat ./App_Data/Logs/20230825/info-20230825.log.5