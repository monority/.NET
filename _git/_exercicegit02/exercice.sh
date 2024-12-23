# 1
git init
touch file_01.txt
# 2
git add file_01.txt
git commit -m "NEW file_01"
#3
touch file_02.txt
git add file_02.txt
git commit -m "NEW file_02"
# 4
git log
# 5
echo "New content for file_02.txt" > file_02.txt
git add file_02.txt
git commit -m "CHANGES file_02 content"
# 6
git reset --hard HEAD~1                        
# 7
git log
# 8 
git branch dev HEAD~1
# 9
